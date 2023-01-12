import { Component, OnInit } from '@angular/core';
import { Mascota } from 'src/app/interfaces/mascotas';



const ELEMENT_DATA: Mascota[] = [
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
export class ListadoMascotaComponent implements OnInit {
  displayedColumns: string[] = ['nombre', 'color', 'edad','raza','peso'];
  dataSource = ELEMENT_DATA;
  constructor() { }

  ngOnInit(): void {
  }

}
