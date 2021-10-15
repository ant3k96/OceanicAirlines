import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {
  FindAirportRouteResponse,
  RouteClient,
} from 'src/app/services/services';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.css'],
})
export class RecordsComponent implements OnInit {
  responses: FindAirportRouteResponse[] | null = [];
  constructor(
    private routeClient: RouteClient,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.routeClient
      .getHistory()
      .subscribe((data: FindAirportRouteResponse[] | null) => {
        this.responses = data;
      }, (error) => {
        this.toastr.error(error);
      });
  }
}
