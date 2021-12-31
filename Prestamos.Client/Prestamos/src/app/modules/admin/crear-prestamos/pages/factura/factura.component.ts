import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Prestamo } from 'src/app/Core/models/prestamos/prestamo.model';
import { CronogramprestamoPdfService } from '../../services/cronograma-prestamo-pdf.service';
import { PrestamoService } from '../../services/prestamo.service';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.scss']
})
export class FacturaComponent implements OnInit, OnDestroy {
  isLoanding: boolean = false;
  constructor(private route: ActivatedRoute, 
    private router: Router,
    private pdfService: CronogramprestamoPdfService,
    private prestamoService: PrestamoService) {
      this.isLoanding = true;
      const id = +this.route.snapshot.paramMap.get('id')!;
      this.prestamoService.getPrestamoById(id).subscribe(res => {
        this.pdfService.setData(res.data);
        this.pdfService.generatePdf();
        this.isLoanding = false;
      }, error => {
        this.isLoanding = false;
        this.router.navigate(['admin/crear-prestamos']);
      });
  }


  ngOnInit(): void {
  }

  imprimir(){
    this.pdfService.print();
  }

  visualizar(){
    this.pdfService.open();
  }

  descargar(){
    this.pdfService.download('Prestamo');
  }

  ngOnDestroy(): void {
    this.pdfService.clear();
  }

}
