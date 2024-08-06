import { Component, EventEmitter, Output, input } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { Author } from '../../../models/author.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-form-author',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './form-author.component.html',
  styleUrl: './form-author.component.css'
})
export class FormAuthorComponent {

  author = input<Author | null>(null);

  form!: FormGroup

  @Output() save = new EventEmitter<Author>();

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl<string>(this.author()?.name ?? '', {
        nonNullable: true,
        validators: [ Validators.required, Validators.maxLength(40) ]
      })
    });
  }

  onSubmit() {
    const author = this.form.value as Author;
    this.save.emit(author);
  }

}
