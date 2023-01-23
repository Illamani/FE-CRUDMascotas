import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Mascota } from 'src/app/interfaces/mascotas';
import { MascotaService } from 'src/app/services/mascota.service';

@Component({
  selector: 'app-ver-mascota',
  templateUrl: './ver-mascota.component.html',
  styleUrls: ['./ver-mascota.component.css']
})
export class VerMascotaComponent implements OnInit {

  id : number;
  mascota! : Mascota;
  // mascota$! : Observable<Mascota>
  constructor(private _mascotasServices : MascotaService,
    private aRoute: ActivatedRoute) { 
      this.id = Number(this.aRoute.snapshot.paramMap.get('id')!)
    }

  ngOnInit(): void {
    // this.mascota$ = this._mascotasServices.getMascota(this.id)
    this.obtenerMascotas();
  }

  obtenerMascotas(){
    this._mascotasServices.getMascota(this.id).subscribe(
      data => {
        this.mascota = data
      }
    )
  }
}
