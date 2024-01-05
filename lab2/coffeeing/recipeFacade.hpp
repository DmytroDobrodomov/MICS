#pragma once

#include <vector>
#include <iostream>

#include "liquids/liquid.hpp"
#include "liquids/espresso.hpp"
#include "liquids/milk.hpp"
#include "liquids/water.hpp"
#include "ui/buttonListener.hpp"






class RecipeFacade
{
public:
    RecipeFacade(std::vector<Liquids::Liquid*> * rr){
        recipe = rr;
    }

    void MakeRecipe(std::string recName){
        if(recName==ESPRESSO) MakeEspresso();
        if(recName==LATTE) MakeLatte();
        if(recName==CAPPUCINO) MakeCappucino();
    }

private:
    std::vector<Liquids::Liquid*> * recipe;
    
    void MakeEspresso(){
        recipe->clear();
        recipe->push_back((Liquids::Liquid*)(new Liquids::Espresso(40)));
    }

    void MakeLatte(){
        recipe->clear();
        recipe->push_back((Liquids::Liquid*)(new Liquids::Espresso(40)));
        recipe->push_back((Liquids::Liquid*)(new Liquids::Milk(80)));
        recipe->push_back((Liquids::Liquid*)(new Liquids::WhipMilk(120)));
    }

    void MakeCappucino(){
        recipe->clear();
        recipe->push_back((Liquids::Liquid*)(new Liquids::Espresso(30)));
        recipe->push_back((Liquids::Liquid*)(new Liquids::Milk(80)));
        recipe->push_back((Liquids::Liquid*)(new Liquids::WhipMilk(100)));
        recipe->push_back((Liquids::Liquid*)(new Liquids::Espresso(10)));
    }

};


