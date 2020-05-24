import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-confirm-dialog',
  templateUrl: 'confirmDialog.component.html',
})
export class ConfirmDialogComponent {
  public readonly ACTION_YES: string = 'YES';
  public readonly ACTION_NO: string = 'NO';
  public readonly ACTION_CANCEL: string = 'CANCELED';
  public readonly ACTION_IGNORE: string = 'IGNORED';
  public readonly ACTION_OK: string = 'OK';
  public readonly ACTION_CLOSE: string = 'CLOSED';
  public readonly ACTION_CONFIRM: string = 'CONFIRMED';
  constructor(
    private dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

    close(){
      this.dialogRef.close(1);
    }
}
