import { Component, inject } from '@angular/core';
import { BookService } from '../../../services/book.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormBookComponent } from "../form-book/form-book.component";
import { Book } from '../../../models/book.model';

@Component({
  selector: 'app-create-book',
  standalone: true,
  imports: [FormBookComponent],
  providers: [HttpClient],
  templateUrl: './create-book.component.html',
  styleUrl: './create-book.component.css'
})
export class CreateBookComponent {

  bookService = inject(BookService);
  router = inject(Router);

  onSubmit(book: Book) {
    this.bookService.createBook(book).subscribe(() => {
      this.router.navigateByUrl('/livros')
    })
  }
}
