import React, { useState } from "react";
import Select from "react-select";

// import { Container } from './styles';

function AutoComplete({
  data,
  onChange,
  onSelected,
  placeholder,
  value,
  ...res
}) {
  const controlStyle =
    "rounded-lg border undefined block flex-1 min-w-0 w-full p-2.5";
  return (
    <Select
      placeholder={placeholder}
      options={data}
      className="basic-multi-select"
      classNamePrefix="select"
      onChange={onChange}
    />
  );
}

export default AutoComplete;
