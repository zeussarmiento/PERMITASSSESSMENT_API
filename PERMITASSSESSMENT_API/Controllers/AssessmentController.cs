using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERMITASSSESSMENT_API.Data;
using PERMITASSSESSMENT_API.IRepository;
using PERMITASSSESSMENT_API.Models;
using System.Diagnostics.Metrics;

namespace PERMITASSSESSMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly ILogger<AssessmentController> _logger;
        private readonly IMapper? _mapper;

        public AssessmentController(IUnitOfWork? unitOfWork, ILogger<AssessmentController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var categories = await _unitOfWork.Categories.GetAll();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var results = _mapper.Map<IList<CategoryDTO>>(categories);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(results);
            }
            catch (Exception ex)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCategories)}");
#pragma warning restore CS8604 // Possible null reference argument.
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("get-category-byid/{id:int}")]
        public async Task<IActionResult> GetCategorybyID(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var category = await _unitOfWork.Categories.Get(q => q.CategoryID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = _mapper.Map<CategoryDTO>(category);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);

        }
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateCategory)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var category = _mapper.Map<Category>(categoryDTO);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Categories.Insert(category);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Save();

            return CreatedAtRoute("GetCategorybyID", new { id = category.CategoryID}, category);

        }
        [HttpPut("update-category/{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var category = await _unitOfWork.Categories.Get(q => q.CategoryID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (category == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
                return BadRequest("Submitted data is invalid");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _mapper.Map(categoryDTO, category);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("delete-category/{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
                return BadRequest();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var category = await _unitOfWork.Categories.Get(q => q.CategoryID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (category == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Categories.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }

        [HttpGet("get-assessment-details")]
        public async Task<IActionResult> GetAssessmentDetails()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var assessment_details = await _unitOfWork.Assessment_Details.GetAll();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var results = _mapper.Map<IList<Assessment_DetailDTO>>(assessment_details);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(results);
            }
            catch (Exception ex)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAssessmentDetails)}");
#pragma warning restore CS8604 // Possible null reference argument.
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("get-assessement-detail-byid/{id:int}")]
        public async Task<IActionResult> GetAssessmentDetailbyID(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var assessmentdetail = await _unitOfWork.Assessment_Details.Get(q => q.Id == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = _mapper.Map<Assessment_DetailDTO>(assessmentdetail);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);

        }
        [HttpPost("create-assessment-detail")]
        public async Task<IActionResult> CreateAssessmentDetail([FromBody] CreateAssessment_DetailDTO assessment_DetailDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateAssessmentDetail)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var assessmentdetail = _mapper.Map<Assessment_Detail>(assessment_DetailDTO);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Assessment_Details.Insert(assessmentdetail);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Save();

            return CreatedAtRoute("GetAssessmentDetailbyID", new { id = assessmentdetail.Id }, assessmentdetail);

        }
        [HttpPut("update-assessment-detail/{id:int}")]
        public async Task<IActionResult> UpdateAssessmentDetail(int id, [FromBody] UpdateAssessment_DetailDTO assessment_DetailDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAssessmentDetail)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var assessmentdetail = await _unitOfWork.Assessment_Details.Get(q => q.Id == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (assessmentdetail == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAssessmentDetail)}");
                return BadRequest("Submitted data is invalid");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _mapper.Map(assessment_DetailDTO, assessmentdetail);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _unitOfWork.Assessment_Details.Update(assessmentdetail);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("delete-assessment-detail/{id:int}")]
        public async Task<IActionResult> DeleteAssessmentDetail(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAssessmentDetail)}");
                return BadRequest();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var assessmentdetail = await _unitOfWork.Assessment_Details.Get(q => q.Id == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (assessmentdetail == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAssessmentDetail)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Assessment_Details.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }

        //Building Computation
        [HttpPost("compute-building")]
        public  async Task<IActionResult> ComputeBuilding(BuildingComputation buildingComputation)
        {
            string StoredProc = "exec spCompute_Buiilding " +
                "@FloorArea = '" + buildingComputation.FloorArea + "'," +
                "@Height = '" + buildingComputation.Height + "'," +
                "@LineGrade = '" + buildingComputation.LineGrade + "'," +
                "@OtherSides = '" + buildingComputation.OtherSides + "'," +
                "@ExcessHeight = '" + buildingComputation.ExcessHeight + "'," +
                "@Additional = '" + buildingComputation.Additional + "'," +
                "@controlnum = '" + buildingComputation.ControlNum + "'," +
                "@catid = " + buildingComputation.CatID + "," +
                "@evaluator = '" + buildingComputation.Evaluator + "'," +
                "@scopeofwork = '" + buildingComputation.ScopeofWork + "'," +
                "@ConsCost = '" + buildingComputation.ProjectCost + "'," +
                "@Excavation = '" + buildingComputation.Excavation + "'";

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Assessment_Details.Output(StoredProc);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok();

        }
        [HttpGet("get-computation-style")]
        public async Task<IActionResult> GetComputationStyle()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var computationstyle = await _unitOfWork.ComputationStyles.GetAll();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var results = _mapper.Map<IList<Assessment_DetailDTO>>(computationstyle);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(results);
            }
            catch (Exception ex)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetComputationStyle)}");
#pragma warning restore CS8604 // Possible null reference argument.
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("get-computation-style-byid/{id:int}")]
        public async Task<IActionResult> GetComputationStylebyID(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var computationstyle = await _unitOfWork.ComputationStyles.Get(q => q.CompStyleID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = _mapper.Map<ComputationSyleDTO>(computationstyle);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);

        }
        [HttpPost("create-computation-style")]
        public async Task<IActionResult> CreateComputationStyle([FromBody] CreateComputationSyleDTO computationSyleDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateComputationStyle)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var computationstyle = _mapper.Map<ComputationStyle>(computationSyleDTO);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.ComputationStyles.Insert(computationstyle);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Save();

            return CreatedAtRoute("GetComputationStylebyID", new { id = computationstyle.CompStyleID }, computationstyle);

        }
        [HttpPut("update-computation-style/{id:int}")]
        public async Task<IActionResult> UpdateComputationStyle(int id, [FromBody] UpdateComputationSyleDTO computationSyleDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateComputationStyle)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var computationstyle = await _unitOfWork.ComputationStyles.Get(q => q.CompStyleID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (computationstyle == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateComputationStyle)}");
                return BadRequest("Submitted data is invalid");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _mapper.Map(computationSyleDTO, computationstyle);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _unitOfWork.ComputationStyles.Update(computationstyle);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("delete-computation-style/{id:int}")]
        public async Task<IActionResult> DeleteComputationStyle(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteComputationStyle)}");
                return BadRequest();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var computationstyle = await _unitOfWork.ComputationStyles.Get(q => q.CompStyleID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (computationstyle == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteComputationStyle)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.ComputationStyles.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }
        [HttpGet("get-fee")]
        public async Task<IActionResult> GetFee()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var fee = await _unitOfWork.Fees.GetAll();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var results = _mapper.Map<IList<FeeDTO>>(fee);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(results);
            }
            catch (Exception ex)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetFee)}");
#pragma warning restore CS8604 // Possible null reference argument.
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("get-fee-byid/{id:int}")]
        public async Task<IActionResult> GetFeebyID(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var fee = await _unitOfWork.Fees.Get(q => q.FeeID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = _mapper.Map<FeeDTO>(fee);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);

        }
        [HttpPost("create-fee")]
        public async Task<IActionResult> CreateFee([FromBody] CreateFeeDTO feeDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateFee)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var fee = _mapper.Map<Fee>(feeDTO);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Fees.Insert(fee);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Save();

            return CreatedAtRoute("GetFeebyID", new { id = fee.FeeID }, fee);

        }
        [HttpPut("update-fee/{id:int}")]
        public async Task<IActionResult> UpdateFee(int id, [FromBody] UpdateFeeDTO feeDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFee)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var fee = await _unitOfWork.Fees.Get(q => q.FeeID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (fee == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFee)}");
                return BadRequest("Submitted data is invalid");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _mapper.Map(feeDTO, fee);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _unitOfWork.Fees.Update(fee);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("delete-fee/{id:int}")]
        public async Task<IActionResult> DeleteFee(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteFee)}");
                return BadRequest();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var fee = await _unitOfWork.Fees.Get(q => q.FeeID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (fee == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteFee)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Fees.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }
        [HttpGet("get-fee-computation")]
        public async Task<IActionResult> GetFeeComputation()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var feecomputation = await _unitOfWork.FeeComputations.GetAll();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var results = _mapper.Map<IList<FeeComputationDTO>>(feecomputation);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(results);
            }
            catch (Exception ex)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetFeeComputation)}");
#pragma warning restore CS8604 // Possible null reference argument.
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("get-fee-computation-byid/{id:int}")]
        public async Task<IActionResult> GetFeeComputationbyID(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var feecomputation = await _unitOfWork.FeeComputations.Get(q => q.FeeID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = _mapper.Map<FeeComputationDTO>(feecomputation);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);

        }
        [HttpPost("create-fee-computation")]
        public async Task<IActionResult> CreateFeeComputation([FromBody] CreateFeeComputationDTO feeComputationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateFeeComputation)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var feecomputation = _mapper.Map<FeeComputation>(feeComputationDTO);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.FeeComputations.Insert(feecomputation);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Save();

            return CreatedAtRoute("GetFeeComputationbyID", new { id = feecomputation.FeeID }, feecomputation);

        }
        [HttpPut("update-fee-computation/{id:int}")]
        public async Task<IActionResult> UpdateFeeComputation(int id, [FromBody] UpdateFeeComputationDTO feeComputationDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFeeComputation)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var feecomputation = await _unitOfWork.FeeComputations.Get(q => q.FeeComputationID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (feecomputation == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateFeeComputation)}");
                return BadRequest("Submitted data is invalid");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _mapper.Map(feeComputationDTO, feecomputation);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _unitOfWork.FeeComputations.Update(feecomputation);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("delete-fee-computation/{id:int}")]
        public async Task<IActionResult> DeleteFeeComputation(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteFeeComputation)}");
                return BadRequest();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var feecomputation = await _unitOfWork.FeeComputations.Get(q => q.FeeComputationID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (feecomputation == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteFeeComputation)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.FeeComputations.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }
        [HttpGet("get-opfeereference")]
        public async Task<IActionResult> GetOPFeeReference()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var opfeereference = await _unitOfWork.OPFeeReferences.GetAll();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var results = _mapper.Map<IList<OPFeeReferenceDTO>>(opfeereference);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(results);
            }
            catch (Exception ex)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOPFeeReference)}");
#pragma warning restore CS8604 // Possible null reference argument.
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("get-opfeereference-byid/{id:int}")]
        public async Task<IActionResult> GetOPFeeReferencebyID(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var opfeereference = await _unitOfWork.OPFeeReferences.Get(q => q.ReferenceID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = _mapper.Map<OPFeeReferenceDTO>(opfeereference);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);

        }
        [HttpPost("create-opfeereference")]
        public async Task<IActionResult> CreateOPFeeReference([FromBody] CreateOPFeeReferenceDTO oPFeeReferenceDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateOPFeeReference)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var opfeereference = _mapper.Map<OPFeeReference>(oPFeeReferenceDTO);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.OPFeeReferences.Insert(opfeereference);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Save();

            return CreatedAtRoute("GetOPFeeReferencebyID", new { id = opfeereference.ReferenceID }, opfeereference);

        }
        [HttpPut("update-opfeereference/{id:int}")]
        public async Task<IActionResult> UpdateOPFeeReference(int id, [FromBody] UpdateOPFeeReferenceDTO oPFeeReferenceDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateOPFeeReference)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var opfeereference = await _unitOfWork.OPFeeReferences.Get(q => q.ReferenceID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (opfeereference == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateOPFeeReference)}");
                return BadRequest("Submitted data is invalid");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _mapper.Map(oPFeeReferenceDTO, opfeereference);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _unitOfWork.OPFeeReferences.Update(opfeereference);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("delete-opfeereference/{id:int}")]
        public async Task<IActionResult> DeleteOPFeeReference(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteOPFeeReference)}");
                return BadRequest();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var opfeereference = await _unitOfWork.OPFeeReferences.Get(q => q.ReferenceID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (opfeereference == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteOPFeeReference)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.OPFeeReferences.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }
        [HttpGet("get-permittype")]
        public async Task<IActionResult> GetPermitType()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var permittype = await _unitOfWork.PermitTypes.GetAll();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var results = _mapper.Map<IList<PermitTypeDTO>>(permittype);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(results);
            }
            catch (Exception ex)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetPermitType)}");
#pragma warning restore CS8604 // Possible null reference argument.
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("get-permittype-byid/{id:int}")]
        public async Task<IActionResult> GetPermitTypebyID(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var permittype = await _unitOfWork.PermitTypes.Get(q => q.PtypeID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = _mapper.Map<PermitTypeDTO>(permittype);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);

        }
        [HttpPost("create-permittype")]
        public async Task<IActionResult> CreatePermitType([FromBody] CreatePermitTypeDTO permitTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreatePermitType)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var permittype = _mapper.Map<PermitType>(permitTypeDTO);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.PermitTypes.Insert(permittype);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _unitOfWork.Save();

            return CreatedAtRoute("GetPermitTypebyID", new { id = permittype.PtypeID }, permittype);

        }
        [HttpPut("update-permittype/{id:int}")]
        public async Task<IActionResult> UpdatePermitType(int id, [FromBody] UpdatePermitTypeDTO permitTypeDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdatePermitType)}");
                return BadRequest(ModelState);
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var permittype = await _unitOfWork.PermitTypes.Get(q => q.PtypeID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (permittype == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdatePermitType)}");
                return BadRequest("Submitted data is invalid");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _mapper.Map(permitTypeDTO, permittype);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _unitOfWork.PermitTypes.Update(permittype);
            await _unitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("delete-permittype/{id:int}")]
        public async Task<IActionResult> DeletePermitType(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeletePermitType)}");
                return BadRequest();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var permittype = await _unitOfWork.PermitTypes.Get(q => q.PtypeID == id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (permittype == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeletePermitType)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.PermitTypes.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }
    }
}
