import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Mascota } from 'src/app/interfaces/mascotas';

@Component({
  selector: 'app-agregar-editar-mascota',
  templateUrl: './agregar-editar-mascota.component.html',
  styleUrls: ['./agregar-editar-mascota.component.css']
})
export class AgregarEditarMascotaComponent implements OnInit {
  loading: boolean = false;

  form: FormGroup
  constructor(private fb: FormBuilder) { 
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
    console.log(mascota);
  }

}
