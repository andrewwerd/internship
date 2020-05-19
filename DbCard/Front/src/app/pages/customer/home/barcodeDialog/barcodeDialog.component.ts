import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
    selector: 'app-barcode-dialog',
    templateUrl: 'barcodeDialog.component.html',
  })
  export class BarcodeDialogComponent {
    constructor(@Inject(MAT_DIALOG_DATA) public data: string) {}
  }
