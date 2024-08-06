import { Component, OnInit, inject } from '@angular/core';
import { Book } from '../../../models/book.model';
import { BookService } from '../../../services/book.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmModalComponent } from '../../shared/confirm-modal/confirm-modal.component';

@Component({
  selector: 'app-list-books',
  standalone: true,
  imports: [ CommonModule, RouterLink],
  providers: [HttpClient],
  templateUrl: './list-books.component.html',
  styleUrl: './list-books.component.css'
})
export class ListBooksComponent {
  bookService = inject(BookService);
  router = inject(Router);
  modalService = inject(NgbModal);
  books: Book[] = inject(ActivatedRoute).snapshot.data['books'];

  loadBooks(): void {
    this.bookService.getBooks().subscribe(data => {
      this.books = data;
    })
  }

  onEdit(id: number): void {
    this.router.navigate(['/livros/atualizar', id])
  }

  onDelete(id: number): void {
    const modalRef = this.modalService.open(ConfirmModalComponent);
    modalRef.componentInstance.message = 'Você realmente deseja excluir este registro?';

    modalRef.result.then((result) => {
      if (result === 'confirmed') {
        this.bookService.deleteBook(id).subscribe(() => {
          this.loadBooks();
        });
      }
    }, (reason) => {
    });
  }
}