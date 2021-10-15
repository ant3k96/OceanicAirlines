import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

  sizes = [
    {size: 'A', "<1kg": '$40', "1-5kg": '$60', ">5kg": '$80'},
    {size: 'B', "<1kg": '$48', "1-5kg": '$68', ">5kg": '$88'},
    {size: 'C', "<1kg": '$80', "1-5kg": '$100', ">5kg": '$120'},
  ]
  displayedSizes: string[] = ['size', '<1kg', '1-5kg', '>5kg'];

  sizesSecond = [
    {size: 'A', "Height (max cm)": '25', "Depth (max cm)": '25', "Breadth (max cm)": '25'},
    {size: 'B', "Height (max cm)": '40', "Depth (max cm)": '40', "Breadth (max cm)": '40'},
    {size: 'C', "Height (max cm)": '200', "Depth (max cm)": '200', "Breadth (max cm)": '200'},
  ]

  displayedSizesSecond: string[] = ['size', 'Height (max cm)', 'Depth (max cm)', 'Breadth (max cm)'];

  thirdTable = [
    {fee: "Recorded Delivery", oa: "Not supported"},
    {fee: "Weapons", oa: "+100%"},
    {fee: "Live animals", oa: "Not supported"},
    {fee: "Cautious parcels", oa: "+75%"},
    {fee: "Refrigerated goods", oa: "+10%"},
  ]

  displayedThird = ['fee', 'oa'];
  constructor() { }

  ngOnInit(): void {
  }

}
