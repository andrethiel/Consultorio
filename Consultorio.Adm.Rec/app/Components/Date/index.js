"use client";
import React, { useState } from "react";
import Button from "../Button";
import { ChevronLeftIcon, ChevronRightIcon } from "@heroicons/react/24/outline";

// import { Container } from './styles';

function Data({ hoje, DataMais, DataMenos }) {
  return (
    <div className="flex gap-5 items-center">
      <Button onClick={DataMenos}>
        <ChevronLeftIcon className="h-6 w-6" />
      </Button>
      <span className="text-lg">{hoje}</span>
      <Button onClick={DataMais}>
        <ChevronRightIcon className="h-6 w-6" />
      </Button>
    </div>
  );
}

export default Data;
