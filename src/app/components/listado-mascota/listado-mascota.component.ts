import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Mascota } from 'src/app/interfaces/mascotas';
import { MascotaService } from 'src/app/services/mascota.service';





@Component({
  selector: 'app-listado-mascota',
  templateUrl: './listado-mascota.component.html',
  styleUrls: ['./listado-mascota.component.css']
})
export class ListadoMascotaComponent implements OnInit,AfterViewInit  {
  displayedColumns: string[] = ['nombre', 'color', 'edad','raza','peso','acciones'];
  dataSource = new MatTableDataSource<Mascota>();
  loading: boolean = false; 
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  constructor(
    private _snackbar: MatSnackBar, 
    private _mascotaService:MascotaService
    ) { }

  ngOnInit(): void {
    this.obtenerMascota()
  }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if(this.dataSource.data.length > 0){
      this.paginator._intl.itemsPerPageLabel = 'Items por pagina'
    }
  }

  obtenerMascota(){
    this.loading = true;
    this._mascotaService.getMascotas().subscribe(data => {
      this.dataSource.data = data
      this.loading = false
    }, error => {
      alert('Ocurrio un error') 
      this.loading = false
    })
  }

  eliminarMascota(){
    this.loading = true;
    setTimeout(() => {  
      this.loading = false;    
      this._snackbar.open(`La mascota fue eliminada con exito`,``,{
        duration: 4000,
        horizontalPosition : `right`,
        
      })
    }, 3000);
  }
}
