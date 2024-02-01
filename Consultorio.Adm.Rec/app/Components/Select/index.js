import { SelectListItem } from "@/Helper/SelectList";
import React from "react";

function Select({
  placeholder,
  data,
  onChange,
  value,
  error,
  selectList,
  ...res
}) {
  return (
    <select
      className="rounded-lg border undefined block flex-1 min-w-0 w-full p-2.5"
      onChange={onChange}
      value={value}
      {...res}
    >
      <option value="0">{placeholder}</option>
      {data.map((item) => SelectListItem(item, selectList))}
    </select>
  );
}

export default Select;
