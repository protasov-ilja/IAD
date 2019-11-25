import { NgModule } from '@angular/core';
import {MatButtonModule } from '@angular/material';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { MatSnackBarModule } from '@angular/material';

@NgModule({
  exports: [
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule
  ]
})
export class MaterialDesignModule {}
