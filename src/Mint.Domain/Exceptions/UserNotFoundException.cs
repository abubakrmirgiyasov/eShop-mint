﻿namespace Mint.Domain.Exceptions;

public class UserNotFoundException(string message) 
    : Exception(message) { }
