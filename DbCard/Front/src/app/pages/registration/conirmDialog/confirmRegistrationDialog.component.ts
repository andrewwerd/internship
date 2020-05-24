import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-register-dialog',
  templateUrl: 'confirmRegistrationDialog.component.html',
})
export class ConfirmRegistrationDialogComponent {
  constructor(
    private dialogRef: MatDialogRef<ConfirmRegistrationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: boolean) { }

    close(){
      this.dialogRef.close(1);
    }
}
