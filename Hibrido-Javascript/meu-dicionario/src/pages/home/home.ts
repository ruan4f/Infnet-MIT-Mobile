import { Component } from '@angular/core';
import { NavController, ToastController, LoadingController } from 'ionic-angular';
import { WordsProvider } from '../../providers/words/words';
import { Storage } from '@ionic/storage';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  words: any[];
  uid: string = '';

  teste = true;

  constructor(
    public navCtrl: NavController,
    private wordService: WordsProvider,
    private toast: ToastController,
    private loadingCtrl: LoadingController,
    private storage: Storage
  ) {

  }

  ionViewDidLoad() {
    this.storage.get('uid').then(uid => {
      this.uid = uid;
      this.wordService.getAll(uid).subscribe(result => {
        this.words = result;
        this.teste = false;
      })
    });
  }

  editWord(word: any) {
    this.navCtrl.push('EditWordPage', { word: word, uid: this.uid });
  }

  removeWord(key: string) {
    if (key) {
      this.wordService.remove(key, this.uid)
        .then(() => {
          this.toast.create({ message: 'Word successfully removed.', duration: 3000 }).present();
        })
        .catch(() => {
          this.toast.create({ message: 'Error removing Word', duration: 3000 }).present();
        });
    }
  }
}
