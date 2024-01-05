#pragma once
#include <SFML/Graphics.hpp>
#include<iostream>


namespace UI{

class Button
{
public:
    std::string name;

    sf::Vector2f size = sf::Vector2f(128,28);
    sf::Vector2f pos= sf::Vector2f(10,10);

    sf::RectangleShape * rect;
    sf::Text * label;

    void Init();

    ~Button(){};

    Button(){
        rect = new sf::RectangleShape();
        label = new sf::Text();

        sf::Font * font = getFont();
        if(font != nullptr)label->setFont(*font);
        
        Init();
    }


    sf::Font * getFont(){
        sf::Font * font = new sf::Font;
        if (!font->loadFromFile("Roboto-Black.ttf"))
        {
            return nullptr;
        }
        return font;
    }
};

void Button::Init()
{
    
    rect->setFillColor(sf::Color(64,64,64));
    rect->setSize(size);
    rect->setPosition(pos);
    rect->setOutlineColor(sf::Color::White);

    label->setFillColor(sf::Color::White);
    label->setCharacterSize(16);
    label->setPosition(pos+sf::Vector2f(4,4));
    label->setString(name);
    
    std::cout << "label: " << label << "\n";
    
}




}