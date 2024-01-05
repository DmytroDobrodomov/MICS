#pragma once
#include <SFML/Graphics.hpp>
#include "liquid.hpp"

namespace Liquids{

class Espresso : public Liquid
{
public:

    Espresso(int ml_)
    {
        ml = ml_;
        color = sf::Color(111, 78, 55);
        name = "espresso";
    };

};


}