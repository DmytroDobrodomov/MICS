#pragma once 

#include <SFML/Graphics.hpp>
#include "liquids/liquid.hpp"
#include "liquids/espresso.hpp"
#include "liquids/milk.hpp"
#include "liquids/water.hpp"
#include "ui/buttonListener.hpp"
#include "recipeFacade.hpp"
#include <vector>


#define W_SIZE 600


#define cupPosX 0
#define cupPosY 100

#define cupSize 300

#define BG_COLOR sf::Color(196, 170, 135)

/// @brief main App class; 
/// call Main()
class App
{
private:
    /// @brief array of different components
    std::vector<Liquids::Liquid*> recipe;

    /// @brief button listener; works with click events
    UI::BListener btnListen;

    /// @brief main app window
    sf::RenderWindow * windowRef;

    /// @brief easy recipes
    RecipeFacade * recipeFacade;

public:
    App(/* args */){};
    ~App(){};

    /// @brief main function with app window
    int Main(){

        
        
        ButtonLayout();
        recipeFacade = new RecipeFacade(&recipe);

        
        sf::RenderWindow window(sf::VideoMode(W_SIZE, W_SIZE), "Coffeeing");
        windowRef = &window;
    
        sf::Texture cupImg;
        if (!cupImg.loadFromFile("sprites/cup.png"))return -1;
        //cupImg.setSmooth(true);

        sf::Texture liqImg;
        if (!liqImg.loadFromFile("sprites/liquidShape.png"))return -1;

        sf::Sprite liqSprite(liqImg);



        sf::Sprite cupSprite;
            cupSprite.setTexture(cupImg);

        

        window.setFramerateLimit(24);
        while (window.isOpen())
        {
            sf::Event event;
            while (window.pollEvent(event))
            {
                if (event.type == sf::Event::Closed)
                    window.close();

                else if (event.type == sf::Event::MouseButtonPressed)
                    _OnButtonClicked(btnListen._OnClick(windowRef));
            }
            
            window.clear(BG_COLOR);

            DisplayLiquid(liqImg);

            
            liqSprite.setTexture(liqImg);

            liqSprite.setPosition(cupPosX,cupPosY);
            cupSprite.setPosition(cupPosX,cupPosY);
            

            
            window.draw(liqSprite);
            window.draw(cupSprite);
            btnListen.DrawButtons(windowRef);
            
            window.display();

        }

        return 0;
    }

private:

    void ButtonLayout(){
        UI::Button cmd;
        cmd.name = ">cmd";
        cmd.pos = sf::Vector2f(500,500);
        cmd.Init();
        btnListen.buttons.push_back(cmd);

        UI::Button buttonE;
        buttonE.name = ESPRESSO;
        buttonE.pos = sf::Vector2f(500,100);
        buttonE.Init();
        btnListen.buttons.push_back(buttonE);

        UI::Button buttonLatte;
        buttonLatte.name = LATTE;
        buttonLatte.pos = sf::Vector2f(500,200);
        buttonLatte.Init();
        btnListen.buttons.push_back(buttonLatte);

        UI::Button buttonC;
        buttonC.name = CAPPUCINO;
        buttonC.pos = sf::Vector2f(500,300);
        buttonC.Init();
        btnListen.buttons.push_back(buttonC);


    }

    /// @brief what liquid layer is here
    /// @param ml current pointer
    Liquids::Liquid* GetLiquidByMl(int ml){
        int mlLeft = ml;
        for(int i = 0; i < recipe.size(); ++i){
            Liquids::Liquid * l = (recipe[i]);
            mlLeft -= l->ml;
            if(mlLeft<=0){
                return l;
            }
        }
        return nullptr;
    }

    
    /// @brief Paint texture to display coffee recipe layers
    /// @param tex 
    /// @param from 
    /// @param to 
    void DisplayLiquid(sf::Texture& tex){
        sf::Image img = tex.copyToImage();
        int currentMl;

        for(int y = 0; y < img.getSize().y; ++y){
            for(int x = 0; x < img.getSize().x; ++x){
                int ml = y*cupSize/img.getSize().y;
                Liquids::Liquid * l = GetLiquidByMl(ml);
                if(img.getPixel(x,img.getSize().y-y-1) != sf::Color::Transparent)
                    if(l != nullptr) {img.setPixel(x,img.getSize().y-y-1,l->color);}
                    else{img.setPixel(x,img.getSize().y-y-1,sf::Color(1,1,1,1));}
            }
        }
        //tex.setSmooth(true);
        tex.loadFromImage(img);
    }

    /// @brief EVENT: button click
    /// @param button name that has been returned
    void _OnButtonClicked(std::string name){
        if(name == "") return;

        //std::cout << "\t" << name << "- BUTTON CLICKED!\n";
        if(name == "rm"){
            if(!recipe.empty())recipe.pop_back();
        }

        if(name == ">cmd"){
            std::string a;
            std::cin >> a;
            return;
        }

        recipeFacade->MakeRecipe(name);

        std::cout << "_________________________\n";
        for (Liquids::Liquid * l : recipe)
        {
            std::cout << l->name << "\n";
        }
        
    }
};


