import React from "react";
import ReactDatePicker, { registerLocale } from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import ptBR from "date-fns/locale/pt-BR";
registerLocale("ptBR", ptBR);

function SelectDatas({ placeholder, onChange, value, error }) {
  return (
    <ReactDatePicker
      className="rounded-lg border undefined block flex-1 min-w-0 w-full p-2.5"
      placeholderText={placeholder}
      selected={value}
      onChange={onChange}
      dateFormat={"dd/MM/yyyy"}
      locale="ptBR"
    />
  );
}

export default SelectDatas;
