import { Component, OnInit, inject } from '@angular/core';
import { SaleType } from '../../../models/saletype.model';
import { SaleTypeService } from '../../../services/saletype.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmModalComponent } from '../../shared/confirm-modal/confirm-modal.component';

@Component({
  selector: 'app-list-saletypes',
  standalone: true,
  imports: [ CommonModule, RouterLink],
  providers: [HttpClient],
  templateUrl: './list-saletypes.component.html',
  styleUrl: './list-saletypes.component.css'
})
export class ListSaleTypesComponent {
  saletypeService = inject(SaleTypeService);
  router = inject(Router);
  modalService = inject(NgbModal);
  
  saletypes: SaleType[] = inject(ActivatedRoute).snapshot.data['saletypes'];

  loadSaleTypes(): void {
    this.saletypeService.getSaleTypes().subscribe(data => {
      this.saletypes = data;
    })
  }

  onEdit(id: number): void {
    this.router.navigate(['/tipo-venda/atualizar', id])
  }

  onDelete(id: number): void {
    const modalRef = this.modalService.open(ConfirmModalComponent);
    modalRef.componentInstance.message = 'Você realmente deseja excluir este registro?';

    modalRef.result.then((result) => {
      if (result === 'confirmed') {
        this.saletypeService.deleteSaleType(id).subscribe(() => {
          this.loadSaleTypes();
        });
      }
    }, (reason) => {
    });
  }
}