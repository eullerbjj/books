import { Component, inject } from '@angular/core';
import { SubjectService } from '../../../services/subject.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from '../../../models/subject.model';
import { FormSubjectComponent } from '../form-subject/form-subject.component';

@Component({
  selector: 'app-update-subject',
  standalone: true,
  imports: [FormSubjectComponent],
  providers: [HttpClient],
  templateUrl: './update-subject.component.html',
  styleUrl: './update-subject.component.css'
})
export class UpdateSubjectComponent {
  subjectService = inject(SubjectService);
  router = inject(Router);

  subject: Subject = inject(ActivatedRoute).snapshot.data['subject'];

  onSubmit(subject: Subject) {
    this.subjectService.updateSubject(this.subject.id, subject).subscribe(() => {
      this.router.navigateByUrl('/assuntos')
    })
  }
}
