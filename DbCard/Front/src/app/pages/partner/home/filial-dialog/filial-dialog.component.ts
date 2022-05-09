import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef } from "@angular/material/dialog";

@Component({
    selector: 'app-filial-dialog',
    templateUrl: 'filial-dialog.component.html',
})
export class FilialDialog {
    constructor(
        private dialogRef: MatDialogRef<FilialDialog>,
        private formBuilder: FormBuilder
    ) { }

    filialForm: FormGroup | undefined;

    ngOnInit(): void {
        this.filialForm = this.formBuilder.group({
            Region: ['', [Validators.required]],
            City: ['', [Validators.required]],
            Street: ['', [Validators.required]],
            HouseNumber: ['', [Validators.required]],
            PhoneNumber: ['', [Validators.required]]
        });
    }

    onNoClick(): void {
        this.dialogRef.close();
    }
}