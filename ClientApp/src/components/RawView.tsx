import React, { useState } from 'react'

export default function RawView({ json }: any) {
  const [toggle, setToggle] = useState(false)

  return (
    <>
      <button onClick={() => setToggle(p => !p)}>view raw</button>
      <pre
        style={{ overflowWrap: 'normal', display: toggle ? 'block' : 'none' }}
      >
        {JSON.stringify(json, null, 2)}
      </pre>
    </>
  )
}
