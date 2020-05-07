import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
    selector: 'app-barcode-dialog',
    templateUrl: 'barcode-dialog.html',
  })
  export class BarcodeDialogComponent {
    format = 'CODE128';
    type = 'SVG';
    constructor(@Inject(MAT_DIALOG_DATA) public data: string) {}
  }
