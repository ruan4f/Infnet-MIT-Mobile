//
//  MangaModel.swift
//  meusmangas
//
//  Classe que simboliza o mangá  
//
//  Created by Ruan on 26/09/17.
//  Copyright © 2017 Ruan. All rights reserved.
//

import Foundation

class MangaModel {
    
    var id: String?
    var nome: String?
    var latitude: String?
    var longitude: String?
    
    init(id: String?, nome: String?, latitude: String?, longitude: String?){
        self.id = id
        self.nome = nome
        self.latitude = latitude
        self.longitude = longitude
    }
}
