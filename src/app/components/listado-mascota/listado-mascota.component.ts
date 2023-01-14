import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Mascota } from 'src/app/interfaces/mascotas';



const listMascotas: Mascota[] = [
  {nombre:'Ciro',color:'Dorado',edad:42,raza:'Golden',peso:25},
  {nombre:'Miro',color:'Dorado',edad:44,raza:'Golden',peso:13},
  {nombre:'Milton',color:'Blanco',edad:54,raza:'Pitbull',peso:23},
  {nombre:'Bartolo',color:'Blanco',edad:4,raza:'Chihuahua',peso:45},
  {nombre:'Aquiles',color:'Negro',edad:14,raza:'Policia',peso:25},
  {nombre:'Homero',color:'Negro',edad:16,raza:'Salchicha',peso:65},
  {nombre:'Mark',color:'Azul',edad:77,raza:'Golden',peso:5},
];

@Component({
  selector: 'app-listado-mascota',
  templateUrl: './listado-mascota.component.html',
  styleUrls: ['./listado-mascota.component.css']
})
export class ListadoMascotaComponent implements OnInit,AfterViewInit  {
  displayedColumns: string[] = ['nombre', 'color', 'edad','raza','peso','acciones'];
  dataSource = new MatTableDataSource<Mascota>(listMascotas);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  constructor() { }

  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.paginator._intl.itemsPerPageLabel = 'Items por pagina'
  }

}
