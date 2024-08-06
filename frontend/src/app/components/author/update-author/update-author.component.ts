import { Component, inject } from '@angular/core';
import { AuthorService } from '../../../services/author.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from '../../../models/author.model';
import { FormAuthorComponent } from '../form-author/form-author.component';

@Component({
  selector: 'app-update-author',
  standalone: true,
  imports: [FormAuthorComponent],
  providers: [HttpClient],
  templateUrl: './update-author.component.html',
  styleUrl: './update-author.component.css'
})
export class UpdateAuthorComponent {
  authorService = inject(AuthorService);
  router = inject(Router);

  author: Author = inject(ActivatedRoute).snapshot.data['author'];

  onSubmit(author: Author) {
    this.authorService.updateAuthor(this.author.id, author).subscribe(() => {
      this.router.navigateByUrl('/autores')
    })
  }
}
