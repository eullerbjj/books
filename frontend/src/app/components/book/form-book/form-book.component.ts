import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, input, OnInit, Output } from '@angular/core';
import { FormGroup, FormArray, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { Book } from '../../../models/book.model';
import { SaleTypeService } from '../../../services/saletype.service';
import { SubjectService } from '../../../services/subject.service';
import { AuthorService } from '../../../services/author.service';
import { Author } from '../../../models/author.model';
import { Subject } from '../../../models/subject.model';
import { SaleType } from '../../../models/saletype.model';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-form-book',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NgxMaskDirective ],
  providers: [provideNgxMask()],
  templateUrl: './form-book.component.html',
  styleUrls: ['./form-book.component.css']
})
export class FormBookComponent implements OnInit {
  
  saleTypeService = inject(SaleTypeService);
  subjectService = inject(SubjectService);
  authorService = inject(AuthorService);
  
  book = input<Book | null>(null);
  
  form!: FormGroup;
  
  @Output() save = new EventEmitter<Book>();

  authors: Author[] = [];
  subjects: Subject[] = [];
  saleTypes: SaleType[] = [];
  
  ngOnInit(): void {
    this.loadAuthors();
    this.loadSubjects();
    this.loadSaleTypes();

    this.form = new FormGroup({
      title: new FormControl<string>(this.book()?.title ?? '', {
        nonNullable: true,
        validators: [ Validators.required, Validators.maxLength(40) ]
      }),
      publisher: new FormControl<string>(this.book()?.publisher ?? '', {
        nonNullable: true,
        validators: [ Validators.required, Validators.maxLength(40) ]
      }),
      edition: new FormControl<number | null>(this.book()?.edition ?? null, {
        nonNullable: true,
        validators: Validators.required
      }),
      publicationYear: new FormControl<number | null>(this.book()?.publicationYear ?? null, {
        nonNullable: true,
        validators: [Validators.required,  Validators.min(1500), Validators.max(2050)]
      }),
      saleTypePrices: new FormArray([]),
      authors: new FormArray([]),
      subjects: new FormArray([]),
    });
  }
  
  loadAuthors(): void {
    this.authorService.getAuthors().subscribe(data => {
      this.authors = data;
      const authorsArray = this.form.get('authors') as FormArray;
      this.authors.forEach(author => {
        authorsArray.push(new FormControl(false));
      });

      if (this.book) {
        this.book()?.authors.forEach(author => {
          const index = this.authors.findIndex(a => a.id === author.id);
          if (index >= 0) {
            authorsArray.at(index).setValue(true);
          }
        });
      }
    });
  }

  loadSubjects(): void {
    this.subjectService.getSubjects().subscribe(data => {
      this.subjects = data;
      const subjectsArray = this.form.get('subjects') as FormArray;
      this.subjects.forEach(subject => {
        subjectsArray.push(new FormControl(false));
      });

      if (this.book) {
        this.book()?.subjects.forEach(subject => {
          const index = this.subjects.findIndex(a => a.id === subject.id);
          if (index >= 0) {
            subjectsArray.at(index).setValue(true);
          }
        });
      }
    });
  }

  loadSaleTypes(): void {
    this.saleTypeService.getSaleTypes().subscribe(data => {
      this.saleTypes = data;
  
      const saleTypesArray = this.form.get('saleTypePrices') as FormArray;
  
      this.saleTypes.forEach(saleType => {
        const existingSaleType = this.book()?.prices.find(st => st.saleTypeId === saleType.id);
  
        saleTypesArray.push(
          new FormGroup({
            value: new FormControl(existingSaleType ? existingSaleType.value : '', [Validators.required, Validators.min(0)])
          })
        );
      });
    });
  }

  get saleTypePricesFormArray(): FormArray {
    return this.form.get('saleTypePrices') as FormArray;
  }

  get authorsFormArray(): FormArray {
    return this.form.get('authors') as FormArray;
  }

  get subjectsFormArray(): FormArray {
    return this.form.get('subjects') as FormArray;
  }

  onSubmit(): void {
    const book = this.form.value as Book;
    
    const mapToIds = (items: boolean[], source: { id: number }[]): number[] => 
      items
        .map((selected, index) => (selected ? source[index].id : null))
        .filter((id): id is number => id !== null);

    book.authorIds = mapToIds(this.form.value.authors, this.authors);
    book.subjectIds = mapToIds(this.form.value.subjects, this.subjects);
    book.saleTypePrices = book.saleTypePrices.map((sale: { value: number }, index: number) => ({
      saleTypeId: this.saleTypes[index].id,
      value: sale.value
    }));

    this.save.emit(book);
  }
}
