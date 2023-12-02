# Advent Calendar 2022

[Participate in Advent of code](https://adventofcode.com)

This contains my solutions for [Advent of code 2023](https://adventofcode.com/2023). Solutions are overengineered on purpose as my goal is not to chase stars, but rather to architect the code is such a way that it could theoretically be reused to solve similar problems. The code is not perfect but it's mine ;)!

## Features
I learnt my lesson fromt last year having to write a bunch of boilerplate code which removed a lot of the fun and added a lot of friction to actually solving the problems.
- The ability to automatically grab the day's input
- Unit tests for every problem including the sample data given to everyone
- I've created a generator class to create all the boiler plate code I need for solving problems in my own framework.
- This includes creating the InputParser interface and class and the Solver for the day.
- Thie includes creating the tests that I use to test the sample input and then add the results of the day to.

## New From 2023
- Replaced the Moq testing framework with [FakeItEasy](https://fakeiteasy.github.io/)
