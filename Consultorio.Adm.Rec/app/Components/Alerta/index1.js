import { useEffect, useState } from "react";

export default function Alerta({ children, type }) {
  useEffect(() => {
    setTimeout(() => {
      setMessage(children);
      setCor("");
      //setHiden("none");
    }, 4000);
  }, []);
  const [cor, setCor] = useState("");
  const [message, setMessage] = useState();
  const [hiden, setHiden] = useState("");

  useEffect(() => {
    if (type == "error") {
      setCor("bg-red-500");
    } else {
      setCor("bg-teal-400");
    }
  }, []);
  return (
    <div
      className={`p-4 mb-4 rounded-lg text-sm${cor}`}
      style={{ display: `${hiden}` }}
      role="alert"
    >
      {children}
    </div>
  );
}
