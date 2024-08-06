import { Component, inject } from '@angular/core';
import { BookService } from '../../../services/book.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../../models/book.model';
import { FormBookComponent } from '../form-book/form-book.component';

@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [FormBookComponent],
  providers: [HttpClient],
  templateUrl: './update-book.component.html',
  styleUrl: './update-book.component.css'
})
export class UpdateBookComponent {
  bookService = inject(BookService);
  router = inject(Router);

  book: Book = inject(ActivatedRoute).snapshot.data['book'];

  onSubmit(book: Book) {
    this.bookService.updateBook(this.book.id, book).subscribe(() => {
      this.router.navigateByUrl('/livros')
    })
  }
}
