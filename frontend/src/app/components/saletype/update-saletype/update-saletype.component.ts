import { Component, inject } from '@angular/core';
import { SaleTypeService } from '../../../services/saletype.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { SaleType } from '../../../models/saletype.model';
import { FormSaleTypeComponent } from '../form-saletype/form-saletype.component';

@Component({
  selector: 'app-update-saletype',
  standalone: true,
  imports: [FormSaleTypeComponent],
  providers: [HttpClient],
  templateUrl: './update-saletype.component.html',
  styleUrl: './update-saletype.component.css'
})
export class UpdateSaleTypeComponent {
  saletypeService = inject(SaleTypeService);
  router = inject(Router);

  saletype: SaleType = inject(ActivatedRoute).snapshot.data['saletype'];

  onSubmit(saletype: SaleType) {
    this.saletypeService.updateSaleType(this.saletype.id, saletype).subscribe(() => {
      this.router.navigateByUrl('/tipo-venda')
    })
  }
}
