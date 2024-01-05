#pragma once
#include <SFML/Graphics.hpp>
#include "liquid.hpp"

namespace Liquids{

class Milk : public Liquid
{
public:

    Milk(int ml_)
    {
        ml = ml_;
        color = sf::Color(245, 245, 220);
        name = "milk";
    };


};


class WhipMilk : public Liquid
{
public:

    WhipMilk(int ml_)
    {
        ml = ml_;
        color = sf::Color(255, 255, 235);
        name = "whip milk";
    };

};




}