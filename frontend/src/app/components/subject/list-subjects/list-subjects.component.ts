import { Component, OnInit, inject } from '@angular/core';
import { Subject } from '../../../models/subject.model';
import { SubjectService } from '../../../services/subject.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmModalComponent } from '../../shared/confirm-modal/confirm-modal.component';

@Component({
  selector: 'app-list-subjects',
  standalone: true,
  imports: [ CommonModule, RouterLink],
  providers: [HttpClient],
  templateUrl: './list-subjects.component.html',
  styleUrl: './list-subjects.component.css'
})
export class ListSubjectsComponent {
  subjectService = inject(SubjectService);
  router = inject(Router);
  modalService = inject(NgbModal);
  
  subjects: Subject[] = inject(ActivatedRoute).snapshot.data['subjects'];

  loadSubjects(): void {
    this.subjectService.getSubjects().subscribe(data => {
      this.subjects = data;
    })
  }

  onEdit(id: number): void {
    this.router.navigate(['/assuntos/atualizar', id])
  }

  onDelete(id: number): void {
    const modalRef = this.modalService.open(ConfirmModalComponent);
    modalRef.componentInstance.message = 'Você realmente deseja excluir este registro?';

    modalRef.result.then((result) => {
      if (result === 'confirmed') {
        this.subjectService.deleteSubject(id).subscribe(() => {
          this.loadSubjects();
        });
      }
    }, (reason) => {
    });
  }
}