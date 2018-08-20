import { Component } from '@angular/core';
import { IonicPage, NavController, ToastController, LoadingController } from 'ionic-angular';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { WordsProvider } from '../../providers/words/words';
import { Storage } from '@ionic/storage';

@IonicPage()
@Component({
  selector: 'page-add-word',
  templateUrl: 'add-word.html',
})
export class AddWordPage {

  uid: string;
  addWordForm: FormGroup;

  constructor(
    public navCtrl: NavController,
    private formBuilder: FormBuilder,
    private wordService: WordsProvider,
    private toast: ToastController,
    private loadingCtrl: LoadingController,
    private storage: Storage
  ) {
    this.createForm();

    this.storage.get('uid').then(uid => {
      this.uid = uid;
    });
  }

  createForm() {
    this.addWordForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  onSubmit() {
    let loading = this.loadingCtrl.create({
      content: 'Loading...'
    });
    loading.present();
    if (this.addWordForm.valid) {
      this.wordService.save(this.addWordForm.value, this.uid)
        .then(() => {
          loading.dismiss();
          this.addWordForm.reset();
          this.toast.create({ message: 'Word saved successfully.', duration: 3000 }).present();
        })
        .catch((e) => {
          loading.dismiss();
          this.toast.create({ message: 'Error saving the word. Please try again.', duration: 3000 }).present();
        })
    } else {
      loading.dismiss();
    }
  }
}
