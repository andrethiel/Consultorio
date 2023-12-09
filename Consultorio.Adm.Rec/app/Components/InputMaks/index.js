"use client";
import React from "react";
import ReactInputMask from "react-input-mask-next";

// import { Container } from './styles';

function InputMaks({ placeholder, onChange, value, mask }) {
  return (
    <ReactInputMask
      className="rounded-lg border block flex-1 min-w-0 w-full p-2.5"
      mask={mask}
      placeholder={placeholder}
      onChange={onChange}
      value={value}
    />
  );
}

export default InputMaks;
