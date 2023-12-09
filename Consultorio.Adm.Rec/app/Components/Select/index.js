import React from "react";

const medico = ["Medico 1", "Medico 2", "Medico 3", "Medico 4"];

function Select({ placeholder, data, onChange, value, error, ...res }) {
  return (
    <select
      className="rounded-lg border undefined block flex-1 min-w-0 w-full p-2.5"
      onChange={onChange}
      value={value}
      {...res}
    >
      <option value="0">{placeholder}</option>
      {medico.map((item, index) => (
        <option value={index}>{item}</option>
      ))}
    </select>
  );
}

export default Select;
