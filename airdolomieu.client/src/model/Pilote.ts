export class Pilote {
private _numpilote?: number;
private _nompilote?: string;
private _adresse?: string;

  Pilote(numpilote: number, nompilote: string, adresse: string) {
    this._numpilote = numpilote,
      this._nompilote = nompilote,
      this._adresse = adresse

  }
  get numpilote(): number | undefined {
    return this._numpilote
  }

  set numpilote(id  : number) {
    this._numpilote = id;
  }

  get nompilote(): string | undefined {
    return this._nompilote;
  }

  set nompilote(nom: string) {
    this._nompilote = nom;
  }
  get prenompilote(): string | undefined {
    return this._adresse;
  }

  set prenompilote(v: string) {
    this._adresse = v;
  }

  toJson(): any {

    return {

      nompilote: this._nompilote,
      numpilote: this._numpilote ? this._numpilote : undefined,
      adresse: this._adresse ? this._adresse : undefined
    }
  }


}
