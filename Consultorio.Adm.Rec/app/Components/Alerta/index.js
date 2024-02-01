"use client";
import React, { cloneElement, useEffect, useState } from "react";

// import { Container } from './styles';

export default function Alerta({ children, type, show }) {
  console.log(type);
  const [isShow, setIsShow] = useState(show);

  //   useEffect(() => {
  //     setTimeout(() => {
  //       setIsShow(false);
  //       console.log(isShow);
  //     }, 4000);
  //   }, []);

  const renderElAlert = function () {
    return cloneElement(children);
  };

  const handleClose = (e) => {
    e.preventDefault();
    setIsShow(false);
  };

  return (
    isShow && (
      <div
        className={`p-4 mb-4 rounded-lg text-sm ${
          type == "error" ? "bg-red-500" : "bg-teal-400"
        }`}
      >
        <span
          className="ml-4 font-bold float-right text-sm leading-5 cursor-pointer"
          onClick={handleClose}
        >
          &times;
        </span>
        {children}
      </div>
    )
  );
}
