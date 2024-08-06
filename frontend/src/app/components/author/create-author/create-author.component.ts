import { Component, inject } from '@angular/core';
import { AuthorService } from '../../../services/author.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormAuthorComponent } from "../form-author/form-author.component";
import { Author } from '../../../models/author.model';

@Component({
  selector: 'app-create-author',
  standalone: true,
  imports: [FormAuthorComponent],
  providers: [HttpClient],
  templateUrl: './create-author.component.html',
  styleUrl: './create-author.component.css'
})
export class CreateAuthorComponent {

  authorService = inject(AuthorService);
  router = inject(Router);

  onSubmit(author: Author) {
    this.authorService.createAuthor(author).subscribe(() => {
      this.router.navigateByUrl('/autores')
    })
  }
}
