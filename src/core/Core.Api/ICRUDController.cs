using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api
{
    public interface ICRUDController<TKeyType, TEntityDTO>
    {
        public Task<ActionResult> Create([FromBody] TEntityDTO dto);
        public Task<ActionResult> ReadAll();
        public Task<ActionResult> Read(TKeyType id);
        public Task<ActionResult> Update(TKeyType id, [FromBody] TEntityDTO dto);
        public Task<ActionResult> Delete(TKeyType id);

    }
}
