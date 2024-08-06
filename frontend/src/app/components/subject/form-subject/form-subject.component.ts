import { Component, EventEmitter, Output, input } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { Subject } from '../../../models/subject.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-form-subject',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './form-subject.component.html',
  styleUrl: './form-subject.component.css'
})
export class FormSubjectComponent {

  subject = input<Subject | null>(null);

  form!: FormGroup

  @Output() save = new EventEmitter<Subject>();

  ngOnInit(): void {
    this.form = new FormGroup({
      description: new FormControl<string>(this.subject()?.description ?? '', {
        nonNullable: true,
        validators: [ Validators.required, Validators.maxLength(20) ]
      })
    });
  }

  onSubmit() {
    const subject = this.form.value as Subject;
    this.save.emit(subject);
  }

}
