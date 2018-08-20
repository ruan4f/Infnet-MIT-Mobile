import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AngularFireDatabase } from 'angularfire2/database';

@Injectable()
export class WordsProvider {

  private PATH = (uid) => `users/${uid}/words/`;

  constructor(
    public http: HttpClient,
    private db: AngularFireDatabase
  ) {
    console.log('Hello WordsProvider Provider');
  }

  getAll(uid: string) {
    return this.db.list(this.PATH(uid), ref => ref.orderByChild('name'))
      .snapshotChanges()
      .map(changes => {
        return changes.map(c => ({ key: c.payload.key, ...c.payload.val() }));
      });
  }

  get(key: string, uid: string) {
    return this.db.object(this.PATH(uid) + key).snapshotChanges()
      .map(c => {
        return { key: c.key, ...c.payload.val() };
      });
  }

  save(word: any, uid: string) {
    return new Promise((resolve, reject) => {
      if (word.key) {
        this.db.list(this.PATH(uid))
          .update(word.key, { name: word.name, description: word.description })
          .then(() => resolve())
          .catch((e) => reject(e));
      } else {
        this.db.list(this.PATH(uid))
          .push({ name: word.name, description: word.description })
          .then(() => resolve());
      }
    })
  }

  remove(key: string, uid: string) {
    return this.db.list(this.PATH(uid)).remove(key);
  }

}
