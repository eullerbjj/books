import { Component, inject } from '@angular/core';
import { SubjectService } from '../../../services/subject.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormSubjectComponent } from "../form-subject/form-subject.component";
import { Subject } from '../../../models/subject.model';

@Component({
  selector: 'app-create-subject',
  standalone: true,
  imports: [FormSubjectComponent],
  providers: [HttpClient],
  templateUrl: './create-subject.component.html',
  styleUrl: './create-subject.component.css'
})
export class CreateSubjectComponent {

  subjectService = inject(SubjectService);
  router = inject(Router);

  onSubmit(subject: Subject) {
    this.subjectService.createSubject(subject).subscribe(() => {
      this.router.navigateByUrl('/assuntos')
    })
  }
}
