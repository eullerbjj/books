import { Component, OnInit, inject } from '@angular/core';
import { Author } from '../../../models/author.model';
import { AuthorService } from '../../../services/author.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmModalComponent } from '../../shared/confirm-modal/confirm-modal.component';

@Component({
  selector: 'app-list-authors',
  standalone: true,
  imports: [ CommonModule, RouterLink],
  providers: [HttpClient],
  templateUrl: './list-authors.component.html',
  styleUrl: './list-authors.component.css'
})
export class ListAuthorsComponent {
  authorService = inject(AuthorService);
  router = inject(Router);
  modalService = inject(NgbModal);
  authors: Author[] = inject(ActivatedRoute).snapshot.data['authors'];
  
  loadAuthors(): void {
    this.authorService.getAuthors().subscribe(data => {
      this.authors = data;
    })
  }

  onEdit(id: number): void {
    this.router.navigate(['/autores/atualizar', id])
  }

  onDelete(id: number): void {
    const modalRef = this.modalService.open(ConfirmModalComponent);
    modalRef.componentInstance.message = 'Você realmente deseja excluir este registro?';

    modalRef.result.then((result) => {
      if (result === 'confirmed') {
        this.authorService.deleteAuthor(id).subscribe(() => {
          this.loadAuthors();
        });
      }
    }, (reason) => {
    });
  }
}