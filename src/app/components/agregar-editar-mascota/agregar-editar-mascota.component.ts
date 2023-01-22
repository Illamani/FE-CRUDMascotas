import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Mascota } from 'src/app/interfaces/mascotas';
import { MascotaService } from 'src/app/services/mascota.service';

@Component({
  selector: 'app-agregar-editar-mascota',
  templateUrl: './agregar-editar-mascota.component.html',
  styleUrls: ['./agregar-editar-mascota.component.css']
})
export class AgregarEditarMascotaComponent implements OnInit {
  loading: boolean = false;

  form: FormGroup
  constructor(
    private fb: FormBuilder,
    private _mascotaService: MascotaService,
    private _snackBar: MatSnackBar,
    private router : Router
    ) { 
    this.form = this.fb.group({
      nombre:['',Validators.required],
      raza:['',Validators.required],
      color:['',Validators.required],
      edad:['',Validators.required],
      peso:['',Validators.required],
    })
  }

  ngOnInit(): void {
  }
  agregarMascota(){
    const nombre = this.form.value.nombre;
    console.log(nombre);

    const mascota : Mascota = {
      nombre : this.form.value.nombre,
      color : this.form.value.color,
      edad : this.form.value.edad,
      peso : this.form.value.peso,
      raza : this.form.value.raza,
    }
    this._mascotaService.addMascota(mascota).subscribe(data => {
      this.mensajeExito();
      this.router.navigate(['listadoMascotas'])
    })
  }
  mensajeExito(){
    this._snackBar.open(`La mascota fue registrada con exito`,``,{
      duration: 4000,
      horizontalPosition : `right`,
      
    });
  }

}
