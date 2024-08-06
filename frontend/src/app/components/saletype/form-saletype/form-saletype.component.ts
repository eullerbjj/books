import { Component, EventEmitter, Output, input } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { SaleType } from '../../../models/saletype.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-form-saletype',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './form-saletype.component.html',
  styleUrl: './form-saletype.component.css'
})
export class FormSaleTypeComponent {

  saletype = input<SaleType | null>(null);

  form!: FormGroup

  @Output() save = new EventEmitter<SaleType>();

  ngOnInit(): void {
    this.form = new FormGroup({
      description: new FormControl<string>(this.saletype()?.description ?? '', {
        nonNullable: true,
        validators: [ Validators.required, Validators.maxLength(20) ]
      })
    });
  }

  onSubmit() {
    const saletype = this.form.value as SaleType;
    this.save.emit(saletype);
  }

}
