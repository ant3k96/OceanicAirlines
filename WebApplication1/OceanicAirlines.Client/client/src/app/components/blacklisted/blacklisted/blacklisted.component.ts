import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { City, CityClient } from 'src/app/services/services';

@Component({
  selector: 'app-blacklisted',
  templateUrl: './blacklisted.component.html',
  styleUrls: ['./blacklisted.component.css'],
})
export class BlacklistedComponent implements OnInit {
  responses: City[] | null = [];
  blacklistId = new FormControl('', Validators.required);
  constructor(
    private clientClient: CityClient,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getData();  }

  markAsBlacklisted(): void {
    this.clientClient.markAsBlacklisted(this.blacklistId.value).subscribe(() => {
      this.toastr.success('Status changed');
      this.getData();
    }, (error) => {
      this.toastr.error(error);
    })
  }

  getData(): void {
    this.clientClient.getBlacklisted().subscribe((data: City[] | null) => {
      this.responses = data;
    }, (error) => {
      this.toastr.error(error);
    });
  }
}
