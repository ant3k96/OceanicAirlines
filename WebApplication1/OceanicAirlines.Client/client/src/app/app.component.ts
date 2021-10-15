import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import {
  City,
  CityClient,
  FindAirportRouteResponse,
  FindRouteRequest,
  RouteClient,
} from './services/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  searchForm = new FormGroup({
    origin: new FormControl('tanger', Validators.required),
    destination: new FormControl('siera leone', Validators.required),
  });
  response?: FindAirportRouteResponse | null;

  constructor(
    public clientClient: CityClient,
    private routeClient: RouteClient,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  search(): void {
    const origin = this.searchForm.get('origin')!.value;
    const destination = this.searchForm.get('destination')!.value;

    const routeRequest: FindRouteRequest = {
      FromName: origin,
      ToName: destination,
      Size: [20, 20, 20],
      Weight: 50,
      Type: 'weapon',
    };

    this.routeClient
      .findAirportsRoute(routeRequest)
      .subscribe((data: FindAirportRouteResponse | null) => {
        if(!data)
        {
          this.toastr.info('Route not found');
          return;
        }
        this.response = data;

      },
      (error) => {
        this.toastr.error(error);
      });
  }

  registerRoute(): void {
    if (!this.response) {
      return;
    }
    this.routeClient.register(this.response).subscribe(() => {
      this.toastr.success('Successfully saved!');
      this.response = undefined;
      this.searchForm.get('origin')?.setValue(null);
      this.searchForm.get('destination')?.setValue(null);
    }, (error) => {
      this.toastr.error(error);
    })
  }
  title = 'client';
}
