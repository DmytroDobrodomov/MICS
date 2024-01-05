#pragma once
#include <SFML/Graphics.hpp>
#include <vector>
#include<iostream>
#include "button.hpp"

#define TITLE_HEIGHT 24

namespace UI{



class BListener
{

public:
    std::vector<Button> buttons;
    
    std::string _OnClick(sf::Window * w){
        sf::Vector2i cursorPos = (sf::Mouse::getPosition()-w->getPosition()-sf::Vector2i(0,TITLE_HEIGHT));
        std::cout << "event pass [mouse click]: (" << cursorPos.x << ":" << cursorPos.y << ")\n";
        for (Button b : buttons)
        {
            std::cout << "\tbutton from: (" << b.pos.x << ":" << b.pos.y << ")" << " to: (" << b.pos.x+b.size.x << ":" << b.pos.y+b.size.y << ")\n";
            if(
                (cursorPos.x >= b.pos.x && cursorPos.x <= b.pos.x+b.size.x)
                && (cursorPos.y >= b.pos.y && cursorPos.y <= b.pos.y+b.size.y)
            ){
                return b.name;
            }
        }
        return "";
        
    }


    void DrawButtons(sf::RenderWindow * w){
        //std::cout << "aaaaaa";
        if(buttons.empty()) return;
        
        for (Button b : buttons)
        {
            //if(b.rect != nullptr) 
            w->draw(*b.rect);
            //if(b.label != nullptr) 
            w->draw(*b.label);
        }
        
    }

    
};



}