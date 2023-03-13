import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service'
import { Country } from 'src/model/country';
import { FormControl, FormGroup, NgForm, FormBuilder } from '@angular/forms';
import { CountryVat } from 'src/model/countryvat';
import { CalcResponse } from 'src/model/calcResponse';

@Component({
  selector: 'app-calculate',
  templateUrl: './calculate.component.html',
  styleUrls: ['./calculate.component.scss']
})
export class CalculateComponent implements OnInit {
  dataSource1!: Country[];
  dataSource2!: CountryVat[];
  isLoadingResults = false;
  calculateForm!: FormGroup;
  response!: CalcResponse

  selected = '';
  rate: any;

  constructor(private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.calculateForm = this.formBuilder.group({
      'vatRate' : [null],  
      'netAmount' : [null],  
      'vatAmount' : [null],
      'grossAmount' : [null]
    });

    this.api.getCountries()
    .subscribe(res => {
      this.dataSource1 = res;
      console.log(this.dataSource1);
      this.isLoadingResults = false;
      this.countries = this.dataSource1;
    }, err => {
      debugger;
      console.log(err);
      this.isLoadingResults = false;
      alert(err.error);
    });
    
  }

  getVats(id:string){
    this.api.getVatsByCountryId(parseInt(id))
    .subscribe(res => {
      this.dataSource2 = res;
      console.log(this.dataSource2);
      this.isLoadingResults = false;
      this.vats = this.dataSource2;
    }, err => {
      console.log(err);
      this.isLoadingResults = false;
      alert(err.error);
    });
  }

  calculate(form: NgForm){
    this.isLoadingResults = true;
    this.api.calculate(form)
    .subscribe(res => {
      this.response = res;
      console.log(this.response);
      this.isLoadingResults = false;
      this.calculateForm.get('netAmount')?.setValue(this.response.netAmount);
      this.calculateForm.get('vatAmount')?.setValue(this.response.vatAmount);
      this.calculateForm.get('grossAmount')?.setValue(this.response.grossAmount);
    }, err => {
      debugger;
      console.log(err);
      this.isLoadingResults = false;
      alert(err.error);
    });
  }

  selectedFW = new FormControl();
  countries: Country[] = [];
  vats: CountryVat[] = [];
}
