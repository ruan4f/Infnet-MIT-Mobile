import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { EditWordPage } from './edit-word';

@NgModule({
  declarations: [
    EditWordPage,
  ],
  imports: [
    IonicPageModule.forChild(EditWordPage),
  ],
})
export class EditWordPageModule {}
